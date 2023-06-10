using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NLayer.Repository.Seeds
{
    public class GameSeed : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasData(new Game
            {
                Id = 1,
                Title = "Elden Ring",
                GenreId = 1,
                AveragePlayTime = 75,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/1245620/header.jpg?t=1683618443",
                Description = "THE NEW FANTASY ACTION RPG. Rise, Tarnished," +
                              " and be guided by grace to brandish the power of the Elden Ring and become an Elden" +
                              " Lord in the Lands Between.",
                Price = 70


            }, new Game
            {
                Id = 2,
                Title = "Persona 5",
                GenreId = 5,
                AveragePlayTime = 200,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/1687950/header.jpg?t=1679398700",
                Description = "Don the mask and join the Phantom Thieves of Hearts as they stage grand heists," +
                              " infiltrate the minds of the corrupt, and make them change their ways!",
                Price = 65


            }, new Game
            {
                Id = 3,
                Title = "Final Fantasy 14 Online",
                GenreId = 2,
                AveragePlayTime = 500,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/39210/header.jpg?t=1684850999",
                Description = "Take part in an epic and ever-changing FINAL FANTASY as you adventure and explore with" +
                              " friends from around the world.",
                Price = 40


            }, new Game
            {
                Id = 4,
                Title = "Call of Duty Modern Warfare 2",
                GenreId = 3,
                AveragePlayTime = 15,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/1938090/header_alt_assets_3_turkish.jpg?t=1686273395",
                Description = "Call of Duty®: Modern Warfare® II drops players into an unprecedented" +
                              " global conflict that features the return of the iconic Operators of Task Force 141.",
                Price = 80


            }, new Game
            {
                Id = 5,
                Title = "Guild Wars 2",
                GenreId = 2,
                AveragePlayTime = 450,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/1284210/header.jpg?t=1681772992",
                Description = "Guild Wars 2 is an award-winning online roleplaying game with fast-paced action combat," +
                              " deep character customization, and no subscription fee required. Choose from an arsenal" +
                              " of professions and weapons, explore a vast open world," +
                              " compete in PVP modes and more. Join over 16 million players now!",
                Price = 35


            }, new Game
            {
                Id = 6,
                Title = "Trine 4",
                GenreId = 4,
                AveragePlayTime = 23,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/690640/header.jpg?t=1686202010",
                Description = "The best-selling Trine series returns to the magic of 2.5D! Join three iconic" +
                              " heroes as they set off on a quest through fantastical " +
                              "fairytale landscapes to save the world from the Nightmare Prince’s shadows.",
                Price = 15


            }, new Game
            {
                Id = 7,
                Title = "Dark Souls",
                GenreId = 1,
                AveragePlayTime = 65,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/570940/header.jpg?t=1682652141",
                Description = "Then, there was fire. Re-experience the critically acclaimed, genre-defining game" +
                              " that started it all. Beautifully remastered," +
                              " return to Lordran in stunning high-definition detail running at 60fps.",
                Price = 55


            }, new Game
            {
                Id = 8,
                Title = "Dark Souls 2",
                GenreId = 1,
                AveragePlayTime = 80,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/335300/header.jpg?t=1682651964",
                Description = "DARK SOULS™ II: Scholar of the First Sin brings the franchise’s " +
                              "renowned obscurity & gripping gameplay to a new level. Join the " +
                              "dark journey and experience overwhelming" +
                              " enemy encounters, diabolical hazards, and unrelenting challenge.",
                Price = 60


            }, new Game
            {
                Id = 9,
                Title = "Dark Souls 3",
                GenreId = 1,
                AveragePlayTime = 60,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/374320/header.jpg?t=1682651227",
                Description = "Dark Souls continues to push the boundaries with the latest, ambitious chapter" +
                              " in the critically-acclaimed " +
                              "and genre-defining series. Prepare yourself and Embrace The Darkness!",
                Price = 70


            }, new Game
            {
                Id = 10,
                Title = "Sekiro: Shadows Die Twice",
                GenreId = 1,
                AveragePlayTime = 90,
                ImageURL = "https://cdn.akamai.steamstatic.com/steam/apps/814380/header.jpg?t=1678991267",
                Description = "Game of the Year - The Game Awards 2019 Best Action Game of 2019 - IGN Carve" +
                              " your own clever path to vengeance in the award winning adventure from developer" +
                              " FromSoftware, creators of Bloodborne " +
                              "and the Dark Souls series. Take Revenge. Restore Your Honor. Kill Ingeniously.",
                 Price = 60


            });
        }
    }
}
