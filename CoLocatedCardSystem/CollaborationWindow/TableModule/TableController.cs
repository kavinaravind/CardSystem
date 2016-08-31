using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Text.RegularExpressions;

namespace CoLocatedCardSystem.CollaborationWindow.TableModule
{
    class TableController
    {
        CentralControllers controllers;
        AttributeList attributeList;
        ItemList itemList;

        public static String filePath = @"Assets\titanic.csv";

        public TableController(CentralControllers ctrls)
        {
            this.controllers = ctrls;
            Init(filePath);
        }

        /// <summary>
        /// Creates itemController and attributeList, and parses through CSV file
        /// </summary>
        internal void Init(String csvFile)
        {
            itemList = new ItemList();
            attributeList = new AttributeList();
            csvParser(filePath);
        }

        /// <summary>
        /// Clears all objects and sets objects to null
        /// </summary>
        internal void DeInit()
        {
            itemList.DeInit();
            itemList = null;
            attributeList.DeInit();
            attributeList = null;
        }

        /// <summary>
        /// Parses through csv file and adds items to attributeList and itemList
        /// </summary>
        /// <param name="filePath"></param>
        internal async void csvParser(String filePath)
        {
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile file = await folder.GetFileAsync(filePath);
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var sr = new StreamReader(classicStream))
            {
                var lines = new List<String[]>();
                String[] attributes = new String[1];

                int row = 0;
                int counter = 0;

                while (!sr.EndOfStream)
                {
                    String[] Line = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    lines.Add(Line);
                    if (row == 0)
                    {
                        attributes = new String[Line.Length];
                        foreach (String str in Line)
                        {
                            Attribute attr = new Attribute();
                            attr.name = str;
                            attr.values = new List<String>();
                            attributeList.addAttribute(attr);
                            attributes[counter] = str;
                            counter++;
                        }
                    }
                    else if (row == 1)
                    {
                        counter = 0;
                        Dictionary<Attribute, Cell> cellList = new Dictionary<Attribute, Cell>();

                        foreach (String str in Line)
                        {
                            String column = attributes[counter];
                            Attribute currentAttribute = attributeList.attributeList[column];
                            if (isDigitsOnly(str))
                            {
                                currentAttribute.type = ATTRIBUTETYPE.Numerical;
                            }
                            else if (isDate(str))
                            {
                                currentAttribute.type = ATTRIBUTETYPE.Time;
                            }
                            else
                            {
                                currentAttribute.type = ATTRIBUTETYPE.Categorical;
                            }
                            currentAttribute.values.Add(str);
                            Cell cell = createCell(str, currentAttribute.type);
                            cellList.Add(currentAttribute, cell);
                            counter++;
                        }
                        Item item = createItem(cellList);
                        itemList.AddItem(item);
                    }
                    else
                    {
                        Dictionary<Attribute, Cell> cellList = new Dictionary<Attribute, Cell>();
                        counter = 0;
                        foreach (String str in Line)
                        {
                            String column = attributes[counter];
                            Attribute currentAttribute = attributeList.attributeList[column];
                            currentAttribute.values.Add(str);
                            Cell cell = createCell(str, currentAttribute.type);
                            cellList.Add(currentAttribute, cell);
                            counter++;
                        }
                        Item item = createItem(cellList);
                        itemList.AddItem(item);
                    }
                    row++;
                }
            }
        }

        /// <summary>
        /// Checks to see if the cells in the second row are digits or string values
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal bool isDigitsOnly(String str)
        {
            int i;
            return int.TryParse(str, out i);
        }

        /// <summary>
        /// Checks to see if the cells in the second row are dates
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal bool isDate(String str)
        {
            DateTime dateTime;
            return DateTime.TryParse(str, out dateTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal Cell createCell(String data, ATTRIBUTETYPE type)
        {
            Cell cell = new Cell();
            cell.data = data;
            cell.type = type;
            return cell;
        }

        /// <summary>
        /// Creates an item and adds all cells into that item
        /// </summary>
        /// <param name="cellList"></param>
        /// <returns></returns>
        internal Item createItem(Dictionary<Attribute, Cell> cellList)
        {
            Item item = new Item();
            item.cellList = cellList;
            return item;
        }

        /// <summary>
        ///  Returns all items in the itemList
        /// </summary>
        /// <returns></returns>
        internal Item[] GetItem()
        {
            return itemList.getItem();
        }
    }
}
