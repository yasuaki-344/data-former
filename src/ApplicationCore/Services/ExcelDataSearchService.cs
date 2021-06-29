using System;
using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;
using DataFormer.ApplicationCore.Interfaces;
using DataFormer.ApplicationCore.ValueObjects;
using Microsoft.Extensions.Logging;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DataFormer.ApplicationCore.Services
{
    public class ExcelDataSearchService : IExcelDataSearchService
    {
        private readonly ILogger<ExcelDataSearchService> _logger;
        private readonly IExcelFileController _fileController;
        private readonly IExcelDataExtractService _extractor;

        /// <summary>
        /// Initializes a new instance of ExcelDataSearchService class.
        /// </summary>
        /// <param name="logger">Logger object</param>
        /// <param name="fileController">Excel file controll object</param>
        /// <param name="extractor">Excel cell data extract object</param>
        public ExcelDataSearchService(
            ILogger<ExcelDataSearchService> logger,
            IExcelFileController fileController,
            IExcelDataExtractService extractor
        )
        {
            _logger = logger;
            _fileController = fileController;
            _extractor = extractor;
        }

        /// <inheritdoc/>
        public void ExtractData(ExtractConfig config)
        {
            try
            {
                var inputBook = _fileController.Read(config.InputFilePath);
                var outputBook = new XSSFWorkbook();
                foreach (var sheetConfig in config.Sheets)
                {
                    CreateExtractedDataSheet(inputBook, outputBook, sheetConfig);
                }
                _fileController.Write(outputBook, config.OutputFilePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        private void CreateExtractedDataSheet(IWorkbook inputBook, IWorkbook outputBook, SheetConfig config)
        {
            outputBook.CreateSheet(config.SheetName);
            var sheet = outputBook.GetSheet(config.SheetName);
            var i = 0;
            foreach (var columnConfig in config.Columns)
            {
                WriteCell(sheet, 0, i, columnConfig.ColumnName);
                switch (columnConfig.Type)
                {
                    case DataType.Date:
                        foreach (var searchConfig in columnConfig.SearchList)
                        {
                            var inputSheet = inputBook.GetSheet(searchConfig.SheetName);
                            var size = searchConfig.RowSize * searchConfig.ColumnSize;
                            var data = new List<DateTime?>();
                            for (var j = 0; j < size; j++)
                            {
                                var position = _extractor.GetCellPosition(j, searchConfig);
                                data.Add(_extractor.ReadDateTime(inputSheet, position.Row, position.Column));
                            }
                            var k = 1;
                            foreach (var value in data)
                            {
                                if (value != null)
                                {
                                    WriteCell(sheet, k, i, ((DateTime)value).ToString("yyyy/MM/dd HH:mm:ss"));
                                }
                                k++;
                            }
                        }
                        break;
                    case DataType.Label:
                        foreach (var searchConfig in columnConfig.SearchList)
                        {
                            var inputSheet = inputBook.GetSheet(searchConfig.SheetName);
                            var size = searchConfig.RowSize * searchConfig.ColumnSize;
                            var data = new List<string?>();
                            for (var j = 0; j < size; j++)
                            {
                                var position = _extractor.GetCellPosition(j, searchConfig);
                                data.Add(_extractor.ReadLabel(inputSheet, position.Row, position.Column));
                            }
                            var k = 1;
                            foreach (var value in data)
                            {
                                if (value != null)
                                {
                                    WriteCell(sheet, k, i, (string)value);
                                }
                                k++;
                            }
                        }
                        break;
                    case DataType.Numeric:
                        foreach (var searchConfig in columnConfig.SearchList)
                        {
                            var inputSheet = inputBook.GetSheet(searchConfig.SheetName);
                            var size = searchConfig.RowSize * searchConfig.ColumnSize;
                            var data = new List<double?>();
                            for (var j = 0; j < size; j++)
                            {
                                var position = _extractor.GetCellPosition(j, searchConfig);
                                data.Add(_extractor.ReadNumeric(inputSheet, position.Row, position.Column));
                            }
                            var k = 1;
                            foreach (var value in data)
                            {
                                if (value != null)
                                {
                                    WriteNumericToCell(sheet, k, i, (double)value);
                                }
                                k++;
                            }
                        }
                        break;
                    default:
                        _logger.LogWarning($"Do nothing: {columnConfig.Type}");
                        break;
                }
                i++;
            }
        }

        private void WriteCell(ISheet sheet, int rowIndex, int columnIndex, string value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            cell.SetCellValue(value);
        }

        private void WriteNumericToCell(ISheet sheet, int rowIndex, int columnIndex, double value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            cell.SetCellValue(value);
        }
    }
}
