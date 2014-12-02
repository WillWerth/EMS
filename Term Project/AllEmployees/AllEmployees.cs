using System;
using System.Collections.Generic;
using System.Text;
using Supporting;
using System.Text.RegularExpressions;

namespace AllEmployees
{
    /**
* \class Employee
*
*
* \brief ...
*
* This class' purpose is to provide a super type for an employee object. 
* This class represents what an employee can do, and the data pertaining to 
* the specfic employee.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
* This class will primarily only deal with basic data validation.
*
* \note 
*
* \author (last to touch it) $Author: Brandon $
*
* \version $Revision: 1.0 $
*
* \date $Date: 2014/21/11 $
*
* Contact: brandon.d.davison@gmail.com
*
* Created on: Friday November 21 2014
*
* $Id: doxygen-howto.html,v 1.5 2005/04/14 14:16:20 bv Exp $
*
*/
    public class Employee
    {
        public int SIN { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }


        public bool setFirstName(string str)
        {
            bool success = false;
            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(str))
            {
                firstName = str;
                success = true;
            }
            return success;
        }

        public bool setLastName(string str)
        {
            bool success = false;
            Regex r = new Regex("^[a-zA-Z]*$");
            if (r.IsMatch(str))
            {
                lastName = str;
                success = true;
            }
            return success;
        }

        public bool setDOB(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                DOB = date.Date;
                success = true;
            }
            return success;
        }

        public bool setSIN(string num)
        {
            bool success = false;
            int temp;
            string str = num;
            int[] toMult = new int[9];

            for (int i = 0; i < str.Length; i++)
            {
                toMult[i] = (int)Char.GetNumericValue(str[i]);
                if (i % 2 == 1)
                {
                    toMult[i] = toMult[i] * 2;
                    if (toMult[i] > 9)
                    {
                        temp = toMult[i] % 10 + toMult[i] / 10;
                        toMult[i] = temp;
                    }
                }
            }
            temp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                temp += toMult[i];
            }

            if (temp % 10 == 0 && str.Length == 9)
            {
                SIN = int.Parse(num);
                success = true;
            }
            return success;
        }
    }

    /**
* \class FullTimeEmployee
*
*
* \brief ...
*
* This class' purpose is to provide a sub type for an employee. 
* This class represents an employee that works full time within
* the system.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
* This class will primarily only deal with basic data validation.
*
* \note 
*
* \author (last to touch it) $Author: Brandon $
*
* \version $Revision: 1.0 $
*
* \date $Date: 2014/21/11 $
*
* Contact: brandon.d.davison@gmail.com
*
* Created on: Friday November 21 2014
*
* $Id: doxygen-howto.html,v 1.5 2005/04/14 14:16:20 bv Exp $
*
*/
    public class FullTimeEmployee : Employee
    {
        public DateTime dateOfHire { get; set; }
        public DateTime dateOfTermination { get; set; }
        public double salary { get; set; }

        public bool setDOH(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                dateOfHire = date.Date;
                success = true;
            }
            return success;
        }

        public bool setDOT(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                dateOfTermination = date.Date;
                success = true;
            }
            return success;
        }

        public bool setSalary(string str)
        {
            bool success = false;
            double temp;
            if ((temp = Convert.ToDouble(str)) != 0)
            {
                salary = temp;
                success = true;
            }
            return success;
        }
    }

    /**
* \class PartTimeEmployee
*
*
* \brief ...
*
* This class' purpose is to provide a sub type for an employee. 
* This class represents an employee that works part time within
* the system.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
* This class will primarily only deal with basic data validation.
*
* \note 
*
* \author (last to touch it) $Author: Brandon $
*
* \version $Revision: 1.0 $
*
* \date $Date: 2014/21/11 $
*
* Contact: brandon.d.davison@gmail.com
*
* Created on: Friday November 21 2014
*
* $Id: doxygen-howto.html,v 1.5 2005/04/14 14:16:20 bv Exp $
*
*/
    public class PartTimeEmployee : Employee
    {
        public DateTime dateOfHire { get; set; }
        public DateTime dateOfTermination { get; set; }
        public double hourlyWage { get; set; }

        

        public bool setDOT(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                dateOfTermination = date.Date;
                success = true;
            }
            return success;
        }

        public bool setSalary(string str)
        {
            bool success = false;
            double temp;
            if ((temp = Convert.ToDouble(str)) != 0)
            {
                hourlyWage = temp;
                success = true;
            }
            return success;
        }
    }

    /**
* \class ContractEmployee
*
*
* \brief ...
*
* This class' purpose is to provide a sub type for an employee. 
* This class represents an employee that is working under a contract.
* Contract employees only work for the time that is specified in 
* their contract.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
* This class will primarily only deal with basic data validation.
*
* \note 
*
* \author (last to touch it) $Author: Brandon $
*
* \version $Revision: 1.0 $
*
* \date $Date: 2014/21/11 $
*
* Contact: brandon.d.davison@gmail.com
*
* Created on: Friday November 21 2014
*
* $Id: doxygen-howto.html,v 1.5 2005/04/14 14:16:20 bv Exp $
*
*/
    public class ContractEmployee : Employee
    {
        public DateTime contractStart { get; set; }
        public DateTime contractEnd { get; set; }
        public double fixedContractAmmount { get; set; }

        public bool setDOH(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                contractStart = date.Date;
                success = true;
            }
            return success;
        }

        public bool setDOT(string str)
        {
            bool success = false;
            DateTime date;
            if (DateTime.TryParse(str, out date))
            {
                contractEnd= date.Date;
                success = true;
            }
            return success;
        }

        public bool setSalary(string str)
        {
            bool success = false;
            double temp;
            if ((temp = Convert.ToDouble(str)) != 0)
            {
                fixedContractAmmount = temp;
                success = true;
            }
            return success;
        }
    }

    /**
* \class SeasonalEmployee
*
*
* \brief ...
*
* This class' purpose is to provide a sub type for an employee. 
* This class represents an employee that works seasonally within the
* system.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
* This class will primarily only deal with basic data validation.
*
* \note 
*
* \author (last to touch it) $Author: Brandon $
*
* \version $Revision: 1.0 $
*
* \date $Date: 2014/21/11 $
*
* Contact: brandon.d.davison@gmail.com
*
* Created on: Friday November 21 2014
*
* $Id: doxygen-howto.html,v 1.5 2005/04/14 14:16:20 bv Exp $
*
*/
    public class SeasonalEmployee : Employee
    {
        public string season { get; set; }
        public double piecePay { get; set; }

        public bool setSeason(string str)
        {
            bool success = false;
            if (str == "Summer" || str == "Fall" || str == "Winter" || str == "Spring")
            {
                season = str;
                success = true;
            }
            return success;
        }

        public bool setSalary(string str)
        {
            bool success = false;
            double temp;
            if ((temp = Convert.ToDouble(str)) != 0)
            {
                piecePay = temp;
                success = true;
            }
            return success;
        }
    }
}
