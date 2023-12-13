using ContactsApp.Models;
using ContactsApp.Requests.ApartmentRequests;

namespace ContactsApp.Modules
{
    public static class ApartmentModule
    {
        public static void AddApartmentEnpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/apartment", async (ApartmentsContext dbContext) =>
            {
                var test = dbContext.Add(new Apartment());
                await dbContext.SaveChangesAsync();
                return test.Entity.Id;
            });
            app.MapGet("/apartment/{id}", async (ApartmentsContext dbContext, long id) =>
            {
                var test = dbContext.Add(new Apartment());
                await dbContext.SaveChangesAsync();
                return test;
            });

        }
        public static void AddRentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/apartment/{apartmentId}/rent", async (ApartmentsContext dbContext, long apartmentId, AddRentRequest request) =>
            {
                var newRent = new Rent()
                {
                    ApartmentId = apartmentId,
                    WholeAmount = request.WholeAmount,
                    CustomBreakdown = request.CustomBreakdown,
                    Month = request.Month,
                    Year = request.Year,
                    CustomCostBreakDown = request.CustomCostBreakDown,
                    EvenBreakDown = request.EvenBreakDown
                };
                dbContext.Add(newRent);
                await dbContext.SaveChangesAsync();
                return Results.Created("https://localhost:44329/apartment/{apartmentId}/rents", newRent);
            });
            app.MapGet("/apartment/{apartmentId}/rents", (ApartmentsContext dbContext, long apartmentId) =>
            {
                return dbContext.Rents.Select(r => r.ApartmentId == apartmentId);
            });
            app.MapDelete("/apartment/{apartmentId}/rent/{id}", async (ApartmentsContext dbContext, long apartmentId, long rentId) =>
            {
                var rent = dbContext.Rents.FirstOrDefault(r => r.RentId == rentId);
                if (rent is null) throw new Exception("Not found");
                dbContext.Remove(rent);
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            });
        }
        public static void AddRoomateEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/apartment/{apartmentId}/roommate", async (ApartmentsContext dbContext, long apartmentId, AddRoommateRequest request ) =>
            {
                var rommate = new Roommate()
                {
                    ApartmentId = apartmentId,
                    UserId = request.UserId
                };
                dbContext.Add(rommate);
                await dbContext.SaveChangesAsync();
                return Results.Ok();
            });
            app.MapDelete("/apartment/{apartmentId}/roommate/{userId}", async (ApartmentsContext dbContext, long apartmentId, Guid userId) =>
            {
                var roommate = dbContext.Roommates.FirstOrDefault(r => r.UserId == userId);
                if (roommate is null) throw new Exception("Not found");
                dbContext.Remove(roommate);
                await dbContext.SaveChangesAsync();
                return Results.NoContent();
            });
            app.MapGet("/apartment/{apartmentId}/roommates", async (ApartmentsContext dbContext, UserContext userContext,long apartmentId) =>
            {
                var usersIds = (dbContext.Roommates.Where(r => r.ApartmentId == apartmentId)).Select(x => x.UserId);
                if (usersIds is null) throw new Exception("Not found");
                var users = userContext.Users.Add ;
                foreach(var id in users)
                {
                    users.F
                }
                return users.ToList();

            });
        }
    }
}
