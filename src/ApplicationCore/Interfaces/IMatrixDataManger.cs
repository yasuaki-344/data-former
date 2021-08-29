using System.Collections.Generic;
using DataFormer.ApplicationCore.Entities;

namespace DataFormer.ApplicationCore.Interfaces
{
    public interface IMatrixDataManger
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        int GetMaxDataNumber(SearchBlock block);

        /// <summary>
        ///
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="index"></param>
        /// <param name="block"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        (int Row, int Column) GetPosition(int index, SearchBlock block, SearchConfig config);
    }
}
