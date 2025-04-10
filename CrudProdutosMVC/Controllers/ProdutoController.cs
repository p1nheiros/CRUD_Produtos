using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using CrudProdutosMVC.Models;

public class ProdutoController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "api/produtos";
    
    public ProdutoController(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("ProdutosAPI");
    }

    public async Task<IActionResult> Index(int pagina = 1)
    {
        int tamanhoPagina = 10;

        var response = await _httpClient.GetAsync("api/produtos");
        if (!response.IsSuccessStatusCode)
        {
            return View(new List<Produto>());
        }

        var produtos = JsonSerializer.Deserialize<List<Produto>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var produtosPaginados = produtos.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();
        ViewBag.PaginaAtual = pagina;
        ViewBag.TotalPaginas = (int)Math.Ceiling((double)produtos.Count / tamanhoPagina);

        return View(produtosPaginados);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Produto produto)
    {
        if (!ModelState.IsValid)
            return View(produto);

        var jsonContent = new StringContent(JsonSerializer.Serialize(produto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(_apiUrl, jsonContent);

        if (!response.IsSuccessStatusCode)
            return View(produto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Editar(int id)
    {
        var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
        if (!response.IsSuccessStatusCode) return NotFound();

        var json = await response.Content.ReadAsStringAsync();
        var produto = JsonSerializer.Deserialize<Produto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Editar(int id, Produto produto)
    {
        if (!ModelState.IsValid)
            return View(produto);

        var jsonContent = new StringContent(JsonSerializer.Serialize(produto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", jsonContent);

        if (!response.IsSuccessStatusCode)
            return View(produto);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Excluir(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
        return RedirectToAction("Index");
    }
}
