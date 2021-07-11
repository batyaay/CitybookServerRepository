//using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Data;
using Newtonsoft.Json.Linq;
using Citybook.Common.Model;
using GemBox.Spreadsheet;

namespace Citybook.Repository
{
    public class Data
    {
        public bool SaveUser(string userData, string tz)
        {
            try
            {
                if (!string.IsNullOrEmpty(userData)&& !string.IsNullOrEmpty(tz))
                {
                    string path = @"C:\temp\citybookUsers";
                    if (!Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    path = path+ @"\user_" + tz + ".json";

                    using (StreamWriter str = new StreamWriter(path))
                    {
                        str.Write(userData);
                    }
                    SaveToExcel(userData);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void SaveToExcel(string userData)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");


            // Deserialize JSON string
            User user = JsonConvert.DeserializeObject<User>(userData);

            // Create empty excel file with a sheet
            ExcelFile workbook = new ExcelFile();
            ExcelWorksheet worksheet = workbook.Worksheets.Add("Users");
            // Define header values
            worksheet.Cells[0, 0].Value = "First name";
            worksheet.Cells[0, 1].Value = "Last name";
            worksheet.Cells[0, 2].Value = "Tz";
            worksheet.Cells[0, 3].Value = "Birthdate";
            worksheet.Cells[0, 4].Value = "HealthFund";
            worksheet.Cells[0, 5].Value = "MaleOrFemale";
            // Write deserialized values to a sheet
            //int row = 0;

            worksheet.Cells[1, 0].Value = user.FirstName;
            worksheet.Cells[1, 1].Value = user.LastName;
            worksheet.Cells[1, 2].Value = user.Tz;
            worksheet.Cells[1, 3].Value = user.Birthdate;
            worksheet.Cells[1, 4].Value = user.HealthFund;
            worksheet.Cells[1, 5].Value = user.MaleOrFemale;

            // Save excel file
            workbook.Save(@"C:\Users\30190654\Downloads\JsonToExcel" + user.Tz + ".xlsx");
        }


       
    }
}
