using System;
namespace API.Models.Responses;

public class AddKeyToCommunicationResponse
{

	public bool Success { get; set; }

	public string? ErrorMessage { get; set; }

	public string? Communication { get; set; }

	public AddKeyToCommunicationResponse(bool success, string? errorMessage, string? communication)
	{
		Success = success;
		ErrorMessage = errorMessage;
		Communication = communication;
	}
}

