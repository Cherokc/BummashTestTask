using ForgingModelCalculator.Domain.Contracts;
using ForgingModelCalculator.Domain.Models;
using System.Text.RegularExpressions;
using OfficeOpenXml;

namespace ForgingModelCalculator.Web.Repositories
{
    public class ExcelDataRepository : IRolledRingToleranceAllowanceRepository
    {
        private readonly string _excelFilePath;

        public ExcelDataRepository(IConfiguration configuration)
        {
            _excelFilePath = configuration.GetValue<string>("ExcelFilePath");
        }

        public IReadOnlyList<RolledRingToleranceAllowance> GetAllToleranceAllowances()
        {
            return LoadDataFromExcel().ToList();
        }

        public RolledRingToleranceAllowance GetToleranceAllowance(decimal height, decimal diameter)
        {
            var data = LoadDataFromExcel();
            return data
                .Where(ta => ta.HeightMin < height && ta.HeightMax >= height &&
                       ta.DiameterMin < diameter && ta.DiameterMax >= diameter)
                .First();
        }

        private IEnumerable<RolledRingToleranceAllowance> LoadDataFromExcel()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var toleranceAllowances = new List<RolledRingToleranceAllowance>();

            using var package = new ExcelPackage(new FileInfo(_excelFilePath));
            var worksheet = package.Workbook.Worksheets[0];

            var rowCount = worksheet.Dimension.Rows;
            var colCount = worksheet.Dimension.Columns;

            for (int row = 4; row <= rowCount; row++)
            {
                var minMaxHeights = SplitStringIntoNumbers(worksheet.Cells[row, 1].Text);

                for (int column = 2; column <= colCount; column++)
                {
                    var minMaxDiameters = SplitStringIntoNumbers(worksheet.Cells[2, column].Text);
                    var toleranceAllowance = SplitStringIntoNumbers(worksheet.Cells[row, column].Text);

                    if (toleranceAllowance.Length == 0)
                        continue;

                    if (minMaxDiameters.Length == 1)
                        minMaxDiameters = new[] { 0, minMaxDiameters[0] };

                    toleranceAllowances.Add(new RolledRingToleranceAllowance
                    {
                        HeightMin = minMaxHeights[0],
                        HeightMax = minMaxHeights[1],
                        DiameterMin = minMaxDiameters[0],
                        DiameterMax = minMaxDiameters[1],
                        Allowance = toleranceAllowance[0],
                        Tolerance = toleranceAllowance[1]
                    });
                }
            }

            return toleranceAllowances;
        }

        private decimal[] SplitStringIntoNumbers(string s)
        {
            var matches = Regex.Matches(s, @"-?\d+(\.\d+)?");

            return matches.Cast<Match>()
                          .Select(m => decimal.Parse(m.Value))
                          .ToArray();
        }
    }
}
