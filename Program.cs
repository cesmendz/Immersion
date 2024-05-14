using Microsoft.AspNetCore.Identity;
using user;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();


        var personList = new List<person>()
        {
            new person()
            {
                user = "ces@",
                password = "passcode",
                name = "ces"
            },

             new person()
             {
                user = "irene@",
                password = "pass",
                name = "irene"
             },

              new person()
              {
                user = "thea@",
                password = "code",
                name = "thea"
              },
        };

        //GET ALL
        app.MapGet("/person", () =>
        {
            return Results.Ok(personList);
        });

        //Insert
        app.MapPost("/person", (person newAccount) =>
        {
            personList.Add(newAccount);
            return Results.Ok("Saved Changes");
        });

        //Update
        app.MapPut("/person/{user}", (string user, person updateduser) =>
        {
            var existinguser = personList.FirstOrDefault(a => a.user == user);
            if (existinguser == null)
            {
                return Results.NotFound();
            }

            existinguser.name = updateduser.name;
            existinguser.password = updateduser.password;

            return Results.Ok(existinguser);
        });

        //Delete
        app.MapDelete("/person/{user}", (string user) =>
        {
            var accountToRemove = personList.FirstOrDefault(a => a.user == user);
            if (accountToRemove == null)
            {
                return Results.NotFound();
            }

            personList.Remove(accountToRemove);
            return Results.Ok("Saved Changes");
        });

app.Run();
