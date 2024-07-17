using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Spedizioni.Models;

public class DataAccess
{
    private readonly string _connectionString;

    public DataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public void AddCliente(Cliente cliente)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_AddCliente", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
            cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo);
            cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
            cmd.Parameters.AddWithValue("@PartitaIVA", cliente.PartitaIVA);
            cmd.Parameters.AddWithValue("@Indirizzo", cliente.Indirizzo);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void AddSpedizione(Spedizione spedizione)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_AddSpedizione", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroIdentificativo", spedizione.NumeroIdentificativo);
            cmd.Parameters.AddWithValue("@ClienteId", spedizione.ClienteId);
            cmd.Parameters.AddWithValue("@DataSpedizione", spedizione.DataSpedizione);
            cmd.Parameters.AddWithValue("@Peso", spedizione.Peso);
            cmd.Parameters.AddWithValue("@CittàDestinataria", spedizione.CittàDestinataria);
            cmd.Parameters.AddWithValue("@IndirizzoDestinatario", spedizione.IndirizzoDestinatario);
            cmd.Parameters.AddWithValue("@NominativoDestinatario", spedizione.NominativoDestinatario);
            cmd.Parameters.AddWithValue("@CostoSpedizione", spedizione.CostoSpedizione);
            cmd.Parameters.AddWithValue("@DataConsegnaPrevista", spedizione.DataConsegnaPrevista);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public void AddAggiornamentoSpedizione(AggiornamentoSpedizione aggiornamento)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            SqlCommand cmd = new SqlCommand("sp_AddAggiornamentoSpedizione", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SpedizioneId", aggiornamento.SpedizioneId);
            cmd.Parameters.AddWithValue("@Stato", aggiornamento.Stato);
            cmd.Parameters.AddWithValue("@Luogo", aggiornamento.Luogo);
            cmd.Parameters.AddWithValue("@Descrizione", aggiornamento.Descrizione);
            cmd.Parameters.AddWithValue("@DataOraAggiornamento", aggiornamento.DataOraAggiornamento);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
