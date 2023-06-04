using WebCrawling;
using WebCrawling.Dtos;


const string homeUrl = "https://finalproject.dotnet.gg/";

CrawlerAskingQuestions crawler = new CrawlerAskingQuestions();

CrawlingDto crawlingDto  = crawler.AskIfAllItemsOrNumberOfItemsToBeCrawled();

crawlingDto = crawler.AskQuestionForWhichPriceTobeScraped();

Crawling crawling = new Crawling(homeUrl, crawlingDto);

crawling.NavigateToNextPages();

await crawling.SetActualQuantity();

Console.WriteLine("Crawler completed");

//crawling.Quit();





















