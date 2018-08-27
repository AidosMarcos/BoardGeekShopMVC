using BoardGeekShopMVC.Data.Interfaces;
using BoardGeekShopMVC.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGeekShopMVC.Data.Mocks
{
    public class MockProductRepository : IProductRepository
    {
		private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

		public IEnumerable<Product> Products
		{
			get
			{
				return new List<Product>
				{
					new Product {
						Name ="Champions of Midgard",
						CategoryID = _categoryRepository.Categories.First().CategoryID,
						FullDescription ="Champions of Midgard is a middleweight, Viking-themed, worker placement game with dice rolling in which players are leaders of Viking clans who have traveled to an embattled Viking harbor town to help defend it against the threat of trolls, draugr, and other mythological Norse beasts.",
						ShortDescription = "Champions of Midgard is a middleweight, Viking-themed, worker placement game",
						Price =59.90,
						ImagePath ="/images/ChampionsOfMidgard.jpg",
						InStock = true,
						OnDisplay = true
					},

					new Product{
						Name ="Terraforming Mars",
						CategoryID = _categoryRepository.Categories.First().CategoryID,
						FullDescription ="In Terraforming Mars, you play one of those corporations and work together in the terraforming process, but compete for getting victory points that are awarded not only for your contribution to the terraforming, but also for advancing human infrastructure throughout the solar system, and doing other commendable things.",
						ShortDescription ="In Terraforming Mars, you play one of those corporations and work together in the terraforming process, but compete for getting victory points",
						Price =59.90,
						ImagePath ="/images/TerraformingMars.jpg",
						InStock = true,
						OnDisplay = false
					},

					new Product{
						Name ="Scythe",
						CategoryID =_categoryRepository.Categories.First().CategoryID,
						FullDescription ="Scythe is an engine-building game set in an alternate-history 1920s period. It is a time of farming and war, broken hearts and rusted gears, innovation and valor. In Scythe, each player represents a character from one of five factions of Eastern Europe who are attempting to earn their fortune and claim their faction's stake in the land around the mysterious Factory.",
						ShortDescription ="Scythe is an engine-building game set in an alternate-history 1920s period.",
						Price =69.90,
						ImagePath ="/images/Scythe.jpg",
						InStock = true,
						OnDisplay = false
					},


					new Product{
						Name ="Gloomhaven",
						CategoryID =_categoryRepository.Categories.First().CategoryID,
						FullDescription ="Gloomhaven is a game of Euro-inspired tactical combat in a persistent world of shifting motives. Players will take on the role of a wandering adventurer with their own special set of skills and their own reasons for traveling to this dark corner of the world. ",
						ShortDescription = "Gloomhaven is a game of Euro-inspired tactical combat in a persistent world of shifting motives.",
						Price =89.90,
						ImagePath ="/images/Gloomhaven.jpg",
						InStock = true,
						OnDisplay = false
					},

					new Product{
						Name ="Azul",
						CategoryID =1,
						FullDescription ="In the game Azul, players take turns drafting colored tiles from suppliers to their player board. Later in the round, players score points based on how they've placed their tiles to decorate the palace. Extra points are scored for specific patterns and completing sets; wasted supplies harm the player's score. The player with the most points at the end of the game wins.",
						ShortDescription = "In the game Azul, players take turns drafting colored tiles from suppliers to their player board.",
						Price =39.90,
						ImagePath ="/images/Azul.jpg",
						InStock= true,
						OnDisplay = true
					},

					new Product{
						Name ="Sushi Go!",
						CategoryID =_categoryRepository.Categories.First().CategoryID,
						FullDescription ="In the super-fast sushi card game Sushi Go!, you are eating at a sushi restaurant and trying to grab the best combination of sushi dishes as they whiz by. Score points for collecting the most sushi rolls or making a full set of sashimi. Dip your favorite nigiri in wasabi to triple its value! And once you've eaten it all, finish your meal with all the pudding you've got!",
						ShortDescription = "In the super-fast sushi card game Sushi Go!, you are eating at a sushi restaurant and trying to grab the best combination of sushi dishes as they whiz by.",
						Price =29.90,
						ImagePath ="/images/SushiGo.jpg",
						InStock = true,
						OnDisplay = false
					},

					new Product{
						Name ="TDSO Metal Fire Forge Silver & Black Enamel 7 Dice Polyset",
						CategoryID = _categoryRepository.Categories.Last().CategoryID,
						FullDescription ="This is a 7 Dice Polyset with detailed raised edges and numbers. These are solid metal and one of the most popular dice ranges we do. Contains one of each of the following: D4,D6, D8, D10, D12, D20 and Percentile.",
						ShortDescription = "This is a 7 Dice Polyset with detailed raised edges and numbers",
						Price =35.00,
						ImagePath ="/images/DiceMetal.jpg",
						OnDisplay = false,
						InStock = true
					},

					new Product{
						Name ="TDSO Unicorn Sparkle 7 Dice Polyset",
						CategoryID = _categoryRepository.Categories.Last().CategoryID,
						FullDescription ="This is a standard 16mm full sized dice set. This is a multi colour dice set which a shimmer/sparkle/transparent effect, the highest number on each dice has the unicorn logo instead of the number. Each set contains one of each: D4, D6, D8, D10, D12, D20 and Percentile Dice.",
						ShortDescription = "This is a standard 16mm full sized dice set. This is a multi colour dice set which a shimmer/sparkle/transparent effect",
						Price =9.90,
						ImagePath ="/images/UnicornDice.jpg",
						OnDisplay = true,
						InStock = true,
						},

					new Product{
						Name ="GameScience Opaque Yellow & Black Ink 7 Dice Polyset",
						CategoryID = _categoryRepository.Categories.Last().CategoryID,
						FullDescription ="Absolute Precision 16mm 7 Dice Polyset with hand inked numbers. Contains one each of the following dice: D4, D6, D8, D10, D12, D20 and Percentile. All GameScience precision dice are precision-tested and razor-edged (with sharp points!) because they have not been tumbled or sanded. To smooth down the spot on your die that is rough from being broken from the sprue, simply use hobby/automotive sandpaper. These sharp-edged dice are better than the egg-shaped round-edged imported dice because they will roll accurately.",
						ShortDescription ="Absolute Precision 16mm 7 Dice Polyset with hand inked numbers.",
						Price =29.90,
						ImagePath ="/images/YellowDice.jpg",
						InStock = true,
						OnDisplay = false
					}
				};
			}
		}

		public IEnumerable<Product> OnDisplayProduct { get; }

		public Product GetProductById(int productId)
		{
			throw new NotImplementedException();
		}
	}

}

