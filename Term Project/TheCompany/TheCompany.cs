using System;
using System.Collections.Generic;
using System.Text;
using Supporting;
using AllEmployees;

namespace TheCompany
{
    /**
  * \class Container
  *
  *
  * \brief ...
  *
  * This class' purpose is to provide a container space for the data
  * that will be entering our program from the user, and ouputting to the user.
  * The container will be used to hold valid employee objects. Everytime the
  * container is modified the event will be logged using a logger.
  * Appropriate try catch blocks will be in place for any expected or unexpected failures.
  * This class will primarily deal with invalid data by bouncing the use back to the previous
  * screen and logging a failure.
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
    public class Container
    {
        Logging logger = new Logging();
        static List<Employee> container = new List<Employee>();
        
        /** \brief loadDatabase()
        *   \param string - file - a file to pull from. If null, a default value is used.
        *   \return bool - success - represents the success condition upon exiting 
        *  /the method.
        * 
        *   This methods purpose is to load in a database from the suppot class, verify its
        *   contents, and add it to a local container.
        * 
        */
        public bool loadDatabase()
        {
            return true;
        }

        /** \brief saveContainer()
        *   \return bool - The success state
        * 
        *   This method's purpose is to convert each employee into a record to be saved.
        */
        public bool saveContainer(string file)
        {
            FileIO writer = new FileIO();
            FullTimeEmployee fullTime = new FullTimeEmployee();
            PartTimeEmployee partTime = new PartTimeEmployee();
            SeasonalEmployee seasonal = new SeasonalEmployee();
            ContractEmployee contract = new ContractEmployee();
            string record = "";
            List<string> records = new List<string>();
            foreach(Employee i in container)
            {
                record = "";
                if (i.GetType().IsAssignableFrom(fullTime.GetType()))
                {
                    fullTime = (FullTimeEmployee)i;
                    record = "FT,";
                    record += fullTime.SIN + ",";
                    record += fullTime.firstName + ",";
                    record += fullTime.lastName + ",";
                    record += fullTime.DOB + ",";
                    record += fullTime.dateOfHire + ",";
                    record += fullTime.dateOfTermination + ",";
                    record += fullTime.salary;
                }
                else if (i.GetType().IsAssignableFrom(partTime.GetType()))
                {
                    partTime = (PartTimeEmployee)i;
                    record = "PT,";
                    record += partTime.SIN + ",";
                    record += partTime.firstName + ",";
                    record += partTime.lastName + ",";
                    record += partTime.DOB + ",";
                    record += partTime.dateOfHire + ",";
                    record += partTime.dateOfTermination + ",";
                    record += partTime.hourlyWage;
                }
                else if (i.GetType().IsAssignableFrom(seasonal.GetType()))
                {
                    seasonal = (SeasonalEmployee)i;
                    record = "S,";
                    record += seasonal.SIN + ",";
                    record += seasonal.firstName + ",";
                    record += seasonal.lastName + ",";
                    record += seasonal.DOB + ",";
                    record += seasonal.season + ",";
                    record += seasonal.piecePay;
                }
                else if (i.GetType().IsAssignableFrom(seasonal.GetType()))
                {
                    contract = (ContractEmployee)i;
                    record = "C,";
                    record += contract.SIN + ",";
                    record += contract.firstName + ",";
                    record += contract.lastName + ",";
                    record += contract.DOB + ",";
                    record += contract.contractStart + ",";
                    record += contract.contractEnd+ ",";
                    record += contract.fixedContractAmmount;
                }
                records.Add(record);
            }
            writer.WriteFile(records, file);
            return true;
        }

        /** \brief addItem()
        *   \param Employee - emp - an employee to be added to the container
        *   \return bool - success - represents the success condition upon exiting 
        *  /the method.
        * 
        *   This methods purpose is to add an employee to the local container after it has been
        *   verified for validity
        * 
        */
        public bool addItem(string employee)
        {
            return true;
        }

        /** \brief removeItem()
        *   \param string - ID - an employee to be removed from the container
        *   \return bool - success - represents the success condition upon exiting 
        *  /the method.
        * 
        *   This methods purpose is to search for and remove an item in the local container.
        * 
        */
        public bool removeItem(string ID)
        {
            return true;
        }

        /** \brief modifyItem()
        *   \param string - ID - an employee to be removed from the container.
        *   \param string - field - the field the user wishes to modify.
        *   \param string - vale - the new value to be inserted into the employee. 
        *   \return bool - success - represents the success condition upon exiting 
        *  /the method.
        * 
        *   This methods purpose is to modify a field of an item in the local container.
        * 
        */
        public bool modifyItem(string ID, string field, string value)
        {
            return true;
        }

        /** \brief displayItem()
        *   \param int - itterate - an itterator indicating which employee to display.
        *   \return Employee - emp - an employee to be displayed.
        * 
        *   This method's purpose is to take in an iterator from the UI class and use it to
        *   return an employee to be displayed, allowing traversal.
        */
        public Employee displayItem(int itterate)
        {
            Employee emp = null;
            return emp;
        }
    }
}
