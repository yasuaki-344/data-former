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
        int GetMaxDataNumber(List<SearchConfig> block);

        /// <summary>
        ///
        /// </summary>
        /// <param name="Row"></param>
        /// <param name="index"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        (int Row, int Column) GetPosition(int index, SearchConfig config);
    }
}
