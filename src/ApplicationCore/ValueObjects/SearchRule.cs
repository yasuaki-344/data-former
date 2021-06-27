namespace DataFormer.ApplicationCore.ValueObjects
{
    public record SearchRule
    {
        public SearchDirection Direction { get; init; }
        public int InitialRowPostion { get; init; }
        public int InitialColumnPosition { get; init; }
        public int RowSize { get; init; }
        public int ColumnSize { get; init; }
        public int RowIncrement { get; init; }
        public int ColumnIncrement { get; init; }
    };
}
