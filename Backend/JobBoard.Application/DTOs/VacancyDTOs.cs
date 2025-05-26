using JobBoard.Domain.Enums;

namespace JobBoard.Application.DTOs;

public record CreateVacancyDto(
    long Bet,
    int SalaryTypeId,
    string Title,
    string? Description = null,
    string? Location = null);

public record EditVacancyDto(
    int Id,
    long Bet,
    int SalaryTypeId,
    string Title,
    bool IsActive,
    string? Description = null,
    string? Location = null);