
using Application.Features.Products.Queries.GetAllByOrderId;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers
{
    public class ExcelHelper
    {

        public Byte[] DtoToExcelConvertion(List<ProductGetAllDto> productsGetAllDto)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("Sheet1");

            IRow rowHeader= sheet1.CreateRow(0);
            rowHeader.CreateCell(0).SetCellValue("Id");
            rowHeader.CreateCell(1).SetCellValue("OrderId");
            rowHeader.CreateCell(2).SetCellValue("Name");
            rowHeader.CreateCell(3).SetCellValue("Picture");
            rowHeader.CreateCell(4).SetCellValue("IsOnSale");
            rowHeader.CreateCell(5).SetCellValue("Price");
            rowHeader.CreateCell(6).SetCellValue("SalePrice");

            int index = 1;
            foreach(ProductGetAllDto product in productsGetAllDto)
            {
                IRow row = sheet1.CreateRow(index);
                row.CreateCell(0).SetCellValue(product.Id.ToString());
                row.CreateCell(1).SetCellValue(product.OrderId.ToString());
                row.CreateCell(2).SetCellValue(product.Name.ToString());
                row.CreateCell(3).SetCellValue(product.Picture.ToString());
                row.CreateCell(4).SetCellValue(product.IsOnSale.ToString());
                row.CreateCell(5).SetCellValue(double.Parse(product.Price.ToString()));
                row.CreateCell(6).SetCellValue(double.Parse(product.SalePrice.ToString()));
                index++;
            }
          
            using (var exportData = new MemoryStream())
            {
                workbook.Write(exportData, false);
               

                byte[] bytes = exportData.ToArray();
                return bytes;
            }
        }


    }
}
