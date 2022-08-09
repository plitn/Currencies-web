using System.Net;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGSTestTask.Models;

namespace SGSTestTask.Controllers;

public class CurrencyController : Controller
{
    private const string Datastring = "https://www.cbr-xml-daily.ru/daily_json.js";

    [HttpGet]
    public IActionResult Currency([FromQuery] string id)
    {
        using var hc = new HttpClient();
        var json = hc.GetStringAsync(Datastring);
        var currenciesWrapper = JsonConvert.DeserializeObject<JsonWrapper>(json.Result);
        var currenciesList = currenciesWrapper.Valute.Values.ToList();
        var selectedCurrency = currenciesList.FirstOrDefault(x => x.ID == id);
        if (selectedCurrency == null)
        {
            return NotFound();
        }
        ViewBag.list = (currenciesWrapper.Valute.Values.ToList());
        return View(selectedCurrency);
    }
}