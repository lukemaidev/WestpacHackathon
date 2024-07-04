using System;
namespace API.Models.Requests;

public class AddKeyToCommunicationRequest
{

	public string? Communication { get; set; }

	public string? AccountNumber { get; set; }

	public AddKeyToCommunicationRequest(string communication, string accountNumber)
	{
		Communication = communication;
		AccountNumber = accountNumber;
	}
}

