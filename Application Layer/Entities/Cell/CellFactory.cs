
namespace Entities.Cell
{
    public static class CellFactory
    {
        public static CellProductBase MakeCell(CELL_TYPE cellType)
        {
            CellProductBase cellProductBase = null;
            switch (cellType)
            {
                case CELL_TYPE.OPEN:
                    cellProductBase = new OpenCell(CELL_COLOUR.WHITE);
                    break;
                case CELL_TYPE.CLOSED:
                    cellProductBase = new OpenCell(CELL_COLOUR.BLACK);
                    break;
                case CELL_TYPE.START:
                    cellProductBase = new OpenCell(CELL_COLOUR.RED);
                    break;
                case CELL_TYPE.END:
                    cellProductBase = new OpenCell(CELL_COLOUR.GREEN);
                    break;
                case CELL_TYPE.OCCUPIED:
                    cellProductBase = new OpenCell(CELL_COLOUR.GREY);
                    break;
            }

            return cellProductBase;
        }
    }
}
