using GestionDesCommandes.Data;
using GestionDesCommandes.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesCommandes.Services
{
	public class ClientService : IClientService
	{
		private readonly GestionDesCommandesContext _context;

		public ClientService(GestionDesCommandesContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Client>> GetAllClientsAsync()
		{
			return await _context.Clients.ToListAsync();
		}

		public async Task<Client?> GetClientByIdAsync(int id)
		{
			return await _context.Clients.FindAsync(id);
		}

		public async Task AddClientAsync(Client client)
		{
			_context.Clients.Add(client);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateClientAsync(Client client)
		{
			_context.Clients.Update(client);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteClientAsync(int id)
		{
			var client = await GetClientByIdAsync(id);
			if (client != null)
			{
				_context.Clients.Remove(client);
				await _context.SaveChangesAsync();
			}
		}
	}
}
