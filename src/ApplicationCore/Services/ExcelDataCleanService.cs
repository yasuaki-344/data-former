using System;
using System.IO;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataCleanService : IExcelDataCleanService
    {
        private readonly ILogger<ExcelDataCleanService> _logger;
        private readonly IExcelFileController _fileController;
        private readonly IMatrixDataManger _matrix;
        private readonly IExcelCellAccessor _accessor;
        private readonly ICellDataAccessor _extractor;

        /// <summary>
        /// Initializes a new instance of ExcelDataSearchService class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="fileController">Excel file controll object</param>
        /// <param name="matrix"></param>
        /// <param name="accessor">Excell cell access object </param>
        /// <param name="extractor">Excel cell data read/write object</param>
        public ExcelDataCleanService(
            ILogger<ExcelDataCleanService> logger,
            IExcelFileController fileController,
            IMatrixDataManger matrix,
            IExcelCellAccessor accessor,
            ICellDataAccessor extractor
        )
        {
            _logger = logger;
            _fileController = fileController;
            _matrix = matrix;
            _accessor = accessor;
            _extractor = extractor;
        }

        /// <inheritdoc/>
        public void CleanData(AppConfig config)
        {
            try
            {
                var inputFullPath = Path.GetFullPath(config.InputFilePath);
                var inputBook = _fileController.Read(inputFullPath);
                var outputBook = new XSSFWorkbook();

                foreach (var sheetConfig in config.Sheets)
                {
                    CreateOutputSheet(inputBook, outputBook, sheetConfig);
                }

                var outputFullPath = Path.GetFullPath(config.OutputFilePath);
                _fileController.Write(outputBook, outputFullPath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        /// <summary>
        /// Creates excel sheet based on the specified configuration.
        /// </summary>
        /// <param name="inputBook">Excel workbook to read data</param>
        /// <param name="outputBook">Excel workbook to create sheet</param>
        /// <param name="config">Excel sheet configuration</param>
        private void CreateOutputSheet(IWorkbook inputBook, IWorkbook outputBook, SheetConfig config)
        {
            var sheet = outputBook.CreateSheet(config.SheetName);

            OutputColumnHeaders(sheet, config.Headers);

            var blockRowIndex = 1;
            foreach (var block in config.SearchBlocks)
            {
                var recordNumber = _matrix.GetMaxDataNumber(block);

                var columnIndex = 0;
                foreach (var columnConfig in block.ColumnSearch)
                {
                    outputColumnData(inputBook, columnConfig, blockRowIndex, columnIndex, recordNumber, config.Headers[columnIndex].Type, sheet);
                    columnIndex++;
                }
                blockRowIndex += recordNumber;
            }
        }

        private void OutputColumnHeaders(ISheet sheet, List<ColumnConfig> headers)
        {
            var columnIndex = 0;
            foreach (var columnConfig in headers)
            {
                var cell = _accessor.GetWriteCell(sheet, 0, columnIndex);
                cell.SetCellValue(columnConfig.ColumnName);
                columnIndex++;
            }
        }

        private void outputColumnData(IWorkbook inputBook, SearchConfig columnConfig, int blockRowIndex, int columnIndex, int recordNumber, DataType type, ISheet sheet)
        {
            var inputSheet = inputBook.GetSheet(columnConfig.SheetName);
            for (var i = 0; i < recordNumber; i++)
            {
                var position = _matrix.GetPosition(i, columnConfig);
                var readCell = _accessor.GetReadCell(inputSheet, position.Row, position.Column);
                if (readCell != null)
                {
                    var writeCell = _accessor.GetWriteCell(sheet, blockRowIndex + i, columnIndex);
                    try
                    {
                        _extractor.ExtractCellValue(type, readCell, writeCell);
                    }
                    catch (InvalidOperationException ex)
                    {
                        _logger.LogWarning($"{readCell.RowIndex}, {readCell.ColumnIndex}]:{ex.Message}");
                    }
                    catch (FormatException ex)
                    {
                        _logger.LogWarning($"{readCell.RowIndex}, {readCell.ColumnIndex}]:{ex.Message}");
                    }
                }
            }
        }
    }
}
