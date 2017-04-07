using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DotNetCore.Contacts
{
	public class ContactRepository
	{
		private readonly Func<IDbConnection> connectionProvider;

		public ContactRepository(IConfiguration configuration)
		{
			var connectionString = string.Format(
				"Host={0};Username={1};Password={2};Database={3}",
				configuration["Contacts:DatabaseHost"],
				configuration["Contacts:DatabaseUsername"],
				configuration["Contacts:DatabasePassword"],
				configuration["Contacts:DatabaseName"]);

			connectionProvider = () =>
			{
				var connection = new NpgsqlConnection(connectionString);
				connection.Open();

				return connection;
			};
		}

		public async Task<Contact> AddAsync(Contact contact)
		{
			using (var connection = connectionProvider())
			{
				var ids = await connection.QueryAsync<int>(
					"INSERT INTO contact (FirstName, Surname) VALUES (@FirstName, @Surname) RETURNING id",
					new
					{
						contact.FirstName,
						contact.Surname
					});

				contact.Id = ids.First();
				return contact;
			}
		}

		public async Task<Contact> GetAsync(int id)
		{
			using (var connection = connectionProvider())
			{
				var contacts = await connection.QueryAsync<Contact>(
					"SELECT * FROM contact WHERE Id = @Id",
					new
					{
						Id = id
					});

				return contacts.FirstOrDefault();
			}
		}

		public async Task<IEnumerable<Contact>> GetAsync()
		{
			using (var connection = connectionProvider())
			{
				return await connection.QueryAsync<Contact>("SELECT * FROM contact");
			}
		}

		public async Task DeleteAsync(int id)
		{
			using (var connection = connectionProvider())
			{
				await connection.ExecuteAsync(
					"DELETE FROM contact WHERE Id = @Id",
					new
					{
						Id = id
					});
			}
		}
	}
}
