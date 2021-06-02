using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeHierarchy
{
    public class Functions
    {
        public static string[] readRecord(string searchEmployee, string filePath, int position)
        {
            position--;
            string[] recordNotFound = { "Record Not Found" };


            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(',');
                    if (recordMatches(searchEmployee, fields, position))
                    {
                        int Sal = 0;
                        if(int.TryParse(fields[2].ToString(), out Sal))
                        {
                            Console.WriteLine("Salary {0} is a Valid Integer", fields[2]);
                            
                            if (string.IsNullOrEmpty(fields[1].Length.ToString()))
                               
                            {
                                Console.WriteLine("No Manager Available in this List");
                            }
                            return fields;
                        } else
                        {
                            Console.WriteLine("Salary {0} is NOT a Valid Integer", fields[2]);
                        }
                        
                    }
                }

                return recordNotFound;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something Went Wrong");
                return recordNotFound;
                throw new ApplicationException("Something Went Wrong :", ex);
            }
        }
        public static bool recordMatches(string searchEmployee, string[] record, int position)
        {
            if (record[position].Equals(searchEmployee))
            {
                return true;
            }
            return false;
        }

        public static bool IsSalaryNumeric(string NumericText)
        {
            bool isnumber = true;
            foreach (char c in NumericText)
            {
                isnumber = char.IsNumber(c);
                if (!isnumber)
                {
                    return false;
                }
            }
            return isnumber;
        }
    }
}
