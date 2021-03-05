using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using RVezy.DevTest.Domain.Listing.Infrastructure;
using RVezy.DevTest.Domain.Listing.InputModels;
using RVezy.DevTest.Domain.Listing.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace RVezy.DevTest.Infrastructure.Listing
{
    public class ListingCSVFileRepository : IListingRespository
    {
        List<ListingEntity> listings = new List<ListingEntity>();

        public ListingCSVFileRepository(FileInfo csvLocation)
        {
            // CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture);
            // TextReader reader = new StreamReader(csvLocation.FullName);
            //
            // csvConfig.HasHeaderRecord = true;
            // csvConfig.LineBreakInQuotedFieldIsBadData = false;
            // 
            // var csvReader = new CsvReader(reader, csvConfig);
            //
            // listings = csvReader.GetRecords<ListingEntity>().ToList();

            using (TextFieldParser parser = new TextFieldParser(csvLocation.FullName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                List<string> header = null;

                while (!parser.EndOfData)
                {
                    try
                    {
                        ListingEntity listingEntity = new ListingEntity();

                        //Process row
                        string[] fields = parser.ReadFields();

                        if (header == null)
                        {
                            header = fields.ToList();
                        }
                        else
                        {
                            MapFieldsToEntity(header, fields, listingEntity);
                        }

                        this.listings.Add(listingEntity);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void MapFieldsToEntity(List<string> header, string[] fields, ListingEntity listingEntity)
        {
            listingEntity.id = int.Parse(fields[0]);            
            listingEntity.name = fields[header.IndexOf("name")];
            listingEntity.property_type = fields[header.IndexOf("property_type")];           
        }

        public ListingEntity GetById(int id)
        {
            return listings.Where(x => x.id == id).FirstOrDefault();
        }

        public List<ListingEntity> Search(ListingSearch criteria)
        {
            return new List<ListingEntity>();
        }
    }
}
