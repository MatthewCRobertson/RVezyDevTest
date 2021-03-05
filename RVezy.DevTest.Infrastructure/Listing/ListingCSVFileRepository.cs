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
    /*
     *  REPO for level 1 
     * 
     */
    public class ListingCSVFileRepository : IListingRepository
    {
        List<ListingEntity> listings = new List<ListingEntity>();

        public ListingCSVFileRepository(FileInfo csvLocation)
        {
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

                            this.listings.Add(listingEntity);
                        }                        
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

        public List<ListingEntity> Search(SearchListing criteria)
        {
            return this.listings.Where(x => x.property_type == criteria.PropertyType || criteria.PropertyType == null)
                .Skip(criteria.Offset)
                .Take(criteria.Limit)
                .ToList();
        }

        public int Create(ListingEntity listing)
        {
            // not needed for the Level 1 task.
            throw new NotImplementedException();
        }

        public void Update(ListingEntity listing)
        {
            // not needed for the Level 1 task.
            throw new NotImplementedException();
        }
    }
}
