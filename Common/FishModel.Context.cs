﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FishEntities : DbContext
    {
        public FishEntities()
            : base("name=FishEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ImagePath> ImagePaths { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<TripToLocation> TripToLocations { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int CreateLocation(Nullable<int> userID, string name, string description, string streetAddress, string cityTown, string state, Nullable<int> zipcode, string lattitudeDirection, Nullable<decimal> lattitude, string longitudeDirection, Nullable<decimal> longitude, ObjectParameter output_Result)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var streetAddressParameter = streetAddress != null ?
                new ObjectParameter("StreetAddress", streetAddress) :
                new ObjectParameter("StreetAddress", typeof(string));
    
            var cityTownParameter = cityTown != null ?
                new ObjectParameter("CityTown", cityTown) :
                new ObjectParameter("CityTown", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var zipcodeParameter = zipcode.HasValue ?
                new ObjectParameter("Zipcode", zipcode) :
                new ObjectParameter("Zipcode", typeof(int));
    
            var lattitudeDirectionParameter = lattitudeDirection != null ?
                new ObjectParameter("LattitudeDirection", lattitudeDirection) :
                new ObjectParameter("LattitudeDirection", typeof(string));
    
            var lattitudeParameter = lattitude.HasValue ?
                new ObjectParameter("Lattitude", lattitude) :
                new ObjectParameter("Lattitude", typeof(decimal));
    
            var longitudeDirectionParameter = longitudeDirection != null ?
                new ObjectParameter("LongitudeDirection", longitudeDirection) :
                new ObjectParameter("LongitudeDirection", typeof(string));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("Longitude", longitude) :
                new ObjectParameter("Longitude", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateLocation", userIDParameter, nameParameter, descriptionParameter, streetAddressParameter, cityTownParameter, stateParameter, zipcodeParameter, lattitudeDirectionParameter, lattitudeParameter, longitudeDirectionParameter, longitudeParameter, output_Result);
        }
    
        public virtual int CreateTrip(Nullable<int> userID, string title, string description, string targetedSpecies, string waterConditions, string weatherConditions, string dateOfTrip, string fliesLuresUsed, string catchOfTheDay, string otherNotes, ObjectParameter output_Result)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var targetedSpeciesParameter = targetedSpecies != null ?
                new ObjectParameter("TargetedSpecies", targetedSpecies) :
                new ObjectParameter("TargetedSpecies", typeof(string));
    
            var waterConditionsParameter = waterConditions != null ?
                new ObjectParameter("WaterConditions", waterConditions) :
                new ObjectParameter("WaterConditions", typeof(string));
    
            var weatherConditionsParameter = weatherConditions != null ?
                new ObjectParameter("WeatherConditions", weatherConditions) :
                new ObjectParameter("WeatherConditions", typeof(string));
    
            var dateOfTripParameter = dateOfTrip != null ?
                new ObjectParameter("DateOfTrip", dateOfTrip) :
                new ObjectParameter("DateOfTrip", typeof(string));
    
            var fliesLuresUsedParameter = fliesLuresUsed != null ?
                new ObjectParameter("FliesLuresUsed", fliesLuresUsed) :
                new ObjectParameter("FliesLuresUsed", typeof(string));
    
            var catchOfTheDayParameter = catchOfTheDay != null ?
                new ObjectParameter("CatchOfTheDay", catchOfTheDay) :
                new ObjectParameter("CatchOfTheDay", typeof(string));
    
            var otherNotesParameter = otherNotes != null ?
                new ObjectParameter("OtherNotes", otherNotes) :
                new ObjectParameter("OtherNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTrip", userIDParameter, titleParameter, descriptionParameter, targetedSpeciesParameter, waterConditionsParameter, weatherConditionsParameter, dateOfTripParameter, fliesLuresUsedParameter, catchOfTheDayParameter, otherNotesParameter, output_Result);
        }
    
        public virtual int CreateUpdateTripToLocation(Nullable<int> tripID, Nullable<int> locationID)
        {
            var tripIDParameter = tripID.HasValue ?
                new ObjectParameter("TripID", tripID) :
                new ObjectParameter("TripID", typeof(int));
    
            var locationIDParameter = locationID.HasValue ?
                new ObjectParameter("LocationID", locationID) :
                new ObjectParameter("LocationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUpdateTripToLocation", tripIDParameter, locationIDParameter);
        }
    
        public virtual int CreateUser(string firstName, string lastName, string email, string password)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateUser", firstNameParameter, lastNameParameter, emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<DoesLoginExist_Result> DoesLoginExist(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DoesLoginExist_Result>("DoesLoginExist", emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> DoesTripTitleExistForUser(Nullable<int> userID, string title)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DoesTripTitleExistForUser", userIDParameter, titleParameter);
        }
    
        public virtual ObjectResult<GetAllLocationsForUser_Result> GetAllLocationsForUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllLocationsForUser_Result>("GetAllLocationsForUser", userIDParameter);
        }
    
        public virtual ObjectResult<GetAllTripsForUser_Result> GetAllTripsForUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllTripsForUser_Result>("GetAllTripsForUser", userIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetAssociatedTripForLocation(Nullable<int> locationId)
        {
            var locationIdParameter = locationId.HasValue ?
                new ObjectParameter("LocationId", locationId) :
                new ObjectParameter("LocationId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetAssociatedTripForLocation", locationIdParameter);
        }
    
        public virtual ObjectResult<string> GetImagesForUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetImagesForUser", userIDParameter);
        }
    
        public virtual ObjectResult<GetLocation_Result> GetLocation(Nullable<int> userID, string name)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLocation_Result>("GetLocation", userIDParameter, nameParameter);
        }
    
        public virtual ObjectResult<GetLocationById_Result> GetLocationById(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetLocationById_Result>("GetLocationById", iDParameter);
        }
    
        public virtual ObjectResult<GetTrip_Result> GetTrip(Nullable<int> userID, string title)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTrip_Result>("GetTrip", userIDParameter, titleParameter);
        }
    
        public virtual ObjectResult<GetTripById_Result> GetTripById(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetTripById_Result>("GetTripById", iDParameter);
        }
    
        public virtual ObjectResult<GetUser_Result> GetUser(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetUser_Result>("GetUser", emailParameter);
        }
    
        public virtual int InsertImagePath(Nullable<int> userID, string imagePath)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));
    
            var imagePathParameter = imagePath != null ?
                new ObjectParameter("ImagePath", imagePath) :
                new ObjectParameter("ImagePath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertImagePath", userIDParameter, imagePathParameter);
        }
    
        public virtual int UpdateLocation(Nullable<int> iD, string name, string description, string streetAddress, string cityTown, string state, Nullable<int> zipcode, string lattitudeDirection, Nullable<decimal> lattitude, string longitudeDirection, Nullable<decimal> longitude)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var streetAddressParameter = streetAddress != null ?
                new ObjectParameter("StreetAddress", streetAddress) :
                new ObjectParameter("StreetAddress", typeof(string));
    
            var cityTownParameter = cityTown != null ?
                new ObjectParameter("CityTown", cityTown) :
                new ObjectParameter("CityTown", typeof(string));
    
            var stateParameter = state != null ?
                new ObjectParameter("State", state) :
                new ObjectParameter("State", typeof(string));
    
            var zipcodeParameter = zipcode.HasValue ?
                new ObjectParameter("Zipcode", zipcode) :
                new ObjectParameter("Zipcode", typeof(int));
    
            var lattitudeDirectionParameter = lattitudeDirection != null ?
                new ObjectParameter("LattitudeDirection", lattitudeDirection) :
                new ObjectParameter("LattitudeDirection", typeof(string));
    
            var lattitudeParameter = lattitude.HasValue ?
                new ObjectParameter("Lattitude", lattitude) :
                new ObjectParameter("Lattitude", typeof(decimal));
    
            var longitudeDirectionParameter = longitudeDirection != null ?
                new ObjectParameter("LongitudeDirection", longitudeDirection) :
                new ObjectParameter("LongitudeDirection", typeof(string));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("Longitude", longitude) :
                new ObjectParameter("Longitude", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateLocation", iDParameter, nameParameter, descriptionParameter, streetAddressParameter, cityTownParameter, stateParameter, zipcodeParameter, lattitudeDirectionParameter, lattitudeParameter, longitudeDirectionParameter, longitudeParameter);
        }
    
        public virtual int UpdateTrip(Nullable<int> iD, string title, string description, string targetedSpecies, string waterConditions, string weatherConditions, string dateOfTrip, string fliesLuresUsed, string catchOfTheDay, string otherNotes)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var targetedSpeciesParameter = targetedSpecies != null ?
                new ObjectParameter("TargetedSpecies", targetedSpecies) :
                new ObjectParameter("TargetedSpecies", typeof(string));
    
            var waterConditionsParameter = waterConditions != null ?
                new ObjectParameter("WaterConditions", waterConditions) :
                new ObjectParameter("WaterConditions", typeof(string));
    
            var weatherConditionsParameter = weatherConditions != null ?
                new ObjectParameter("WeatherConditions", weatherConditions) :
                new ObjectParameter("WeatherConditions", typeof(string));
    
            var dateOfTripParameter = dateOfTrip != null ?
                new ObjectParameter("DateOfTrip", dateOfTrip) :
                new ObjectParameter("DateOfTrip", typeof(string));
    
            var fliesLuresUsedParameter = fliesLuresUsed != null ?
                new ObjectParameter("FliesLuresUsed", fliesLuresUsed) :
                new ObjectParameter("FliesLuresUsed", typeof(string));
    
            var catchOfTheDayParameter = catchOfTheDay != null ?
                new ObjectParameter("CatchOfTheDay", catchOfTheDay) :
                new ObjectParameter("CatchOfTheDay", typeof(string));
    
            var otherNotesParameter = otherNotes != null ?
                new ObjectParameter("OtherNotes", otherNotes) :
                new ObjectParameter("OtherNotes", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateTrip", iDParameter, titleParameter, descriptionParameter, targetedSpeciesParameter, waterConditionsParameter, weatherConditionsParameter, dateOfTripParameter, fliesLuresUsedParameter, catchOfTheDayParameter, otherNotesParameter);
        }
    }
}
