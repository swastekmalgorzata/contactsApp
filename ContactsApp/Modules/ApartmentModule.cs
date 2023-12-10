
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
            app.MapPost("/apartment/{apartmentId}/rent", async (ApartmentsContext dbContext, long apartmentId, AddRentRequest rent) =>
            {
                var newRent = new Rent()
                {
                    ApartmentId = apartmentId,
                    WholeAmount = rent.WholeAmount,
                    CustomBreakdown = rent.CustomBreakdown,
                    Month = rent.Month,
                    Year = rent.Year,
                    CustomCostBreakDown = rent.CustomCostBreakDown,
                    EvenBreakDown = rent.EvenBreakDown
                };
                dbContext.Add(newRent);
                await dbContext.SaveChangesAsync();
                return Results.Created("localhost:8080/apartment/{apartmentId}/rents", newRent);
            });
            app.MapGet("/apartment/{apartmentId}/rents", async (ApartmentsContext dbContext, long apartmentId) =>
            {
                return dbContext.Rents.Select(r => r.ApartmentId == apartmentId);
            });
        }
    }
}
