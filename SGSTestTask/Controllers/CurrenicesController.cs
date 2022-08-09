using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGSTestTask.Models;

namespace SGSTestTask.Controllers;

public class CurrenciesController : Controller
{
    private const string Datastring = "https://www.cbr-xml-daily.ru/daily_json.js";

    [HttpGet]
    public IActionResult Currencies([FromQuery] int pgn = 1)
    {
        using var hc = new HttpClient();
        var json = hc.GetStringAsync(Datastring);
        var currenciesWrapper = JsonConvert.DeserializeObject<JsonWrapper>(json.Result);
        ViewBag.pageNumber = pgn;
        ViewBag.path = Request.Path;
        return View("Currencies", currenciesWrapper.Valute.Values.ToList());
    }
}