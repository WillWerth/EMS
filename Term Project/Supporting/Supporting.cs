using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace Supporting
{
    /**
* \class FileIO
*
*
* \brief ...
*
* This class' purpose is to provide File input and output functionality.
* This class will have the ability to open/read/write Employee DBase files.
* This class will also have the ability to read a database record, and write 
* to a database record. This includes parsing data from specific fields.
* Appropriate try catch blocks will be in place for any expected or unexpected failures.
*  
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
    public class FileIO
    {

        public static string winDir = System.Environment.GetEnvironmentVariable("windir");
        public static Logging logger = new Logging();


  /** \brief ReadFile
  *   \param NONE
  *   \return List of strings - represents the database contents
  * 
  *   This method's purpose is to read the contents of an
  *   Employee DBase file. Then return the contents of the
  *   file in a List.
  */
        public static List<string> ReadFile(string file)
        {
            List<string> fileContents = new List<string>();
            StreamReader reader = new StreamReader(winDir + file);
            try
            {
                do
                {
                    fileContents.Add(reader.ReadLine());
                }
                while (reader.Peek() != -1);
            }
            catch(IOException)
            {
                Console.WriteLine("File not read.");
                fileContents.Clear();
            }
            finally
            {
                reader.Close();
            }
            return fileContents;
        }

  /** \brief WriteFile
  *   \param string - record - represents the database record to be written
  *   \return VOID
  * 
  *   This method's purpose is to write a record to an Employee DBase File. 
  *   This method takes in a string, opens the database file, and writes
  *   the record string to the database file using a StreamWriter.
  * 
  */
        public bool WriteFile(List<string> records, string file)
        {
            bool success = true;
            StreamWriter writer = new StreamWriter(winDir + file);
            try
            {
                foreach (string record in records)
                {
                    writer.WriteLine(record);
                }
            }
            catch(IOException)
            {
                success = false;
            }
            finally
            {
                writer.Close();
            }
            return success;
        }
    }

    /**
* \class Logging
*
*
* \brief ...
*
* This class' purpose is to provide logging functionality for the Employee System. 
* It will provide the necessary functionality to log all events and failures within
* the program to allow for easy bugtracking and support.
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
    public class Logging
    {
        public static string winDir = System.Environment.GetEnvironmentVariable("windir");

        /** \brief WriteLog
        *   \param string - record - represents the database record to be written
        *   \return VOID
        * 
        *   This methods purpose is to write data to a logfile. The method
        *   uses a string containing the log, and then writes to it using
        *   a stream writer.
        * 
        */
        public static bool WriteLog(string record)
        {
            bool success = true;
            StreamWriter writer = new StreamWriter(winDir + "\\log.txt");
            try
            {
                writer.WriteLine(record);
            }
            catch(IOException)
            {
                success = false;
            }
            finally
            {
                writer.Close();
            }
            return success;
        }
    }
}
