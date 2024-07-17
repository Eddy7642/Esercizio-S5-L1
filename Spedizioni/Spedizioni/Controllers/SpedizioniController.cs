using Microsoft.AspNetCore.Mvc;
using Spedizioni.Models;
using System;

[Route("api/[controller]")]
[ApiController]
public class SpedizioniController : ControllerBase
{
    private readonly DataAccess _dataAccess;

    public SpedizioniController(DataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    // Endpoint per aggiungere un nuovo cliente
    [HttpPost("cliente")]
    public IActionResult CreateCliente([FromBody] Cliente cliente)
    {
        try
        {
            _dataAccess.AddCliente(cliente);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // Endpoint per aggiungere una nuova spedizione
    [HttpPost("spedizione")]
    public IActionResult CreateSpedizione([FromBody] Spedizione spedizione)
    {
        try
        {
            _dataAccess.AddSpedizione(spedizione);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // Endpoint per aggiungere un aggiornamento di spedizione
    [HttpPost("aggiornamento")]
    public IActionResult CreateAggiornamento([FromBody] AggiornamentoSpedizione aggiornamento)
    {
        try
        {
            _dataAccess.AddAggiornamentoSpedizione(aggiornamento);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // Altri metodi per gestire le richieste (ad es., ottenere i clienti, le spedizioni, ecc.)
}
