using Hospital.Context;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrescriptionsController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] CreatePrescriptionDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Invalid data received");
        }

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                var patient = await _context.Patients.FindAsync(dto.IdPatient);
                if (patient == null)
                {
                    patient = new Patient()
                    {
                        IdPatient = dto.IdPatient,
                        // FirstName = dto.FirstName,
                        // LastName = dto.LastName
                    };
                    _context.Patients.Add(patient);
                }
                
                var doctor = await _context.Doctors.FindAsync(dto.IdDoctor);
                if (doctor == null)
                {
                    return BadRequest($"Doctor with ID {dto.IdDoctor} does not exist");
                }

                if (dto.Medicaments.Count > 10)
                {
                    return BadRequest("A prescription can include a maximum of 10 medicaments");
                }

                foreach (var medicamentDto in dto.Medicaments)
                {
                    var existingMedicament = await _context.Medicaments.FindAsync(medicamentDto.IdMedicament);
                    if (existingMedicament == null)
                    {
                        return BadRequest($"Medicament with ID {medicamentDto.IdMedicament} does not exist");
                    }
                }

                var prescription = new Prescription
                {
                    Date = dto.Date,
                    DueDate = dto.DueDate,
                    IdPatient = dto.IdPatient,
                    IdDoctor = dto.IdDoctor,
                    PrescriptionMedicaments = dto.Medicaments.Select(m => new Prescription_Medicament
                    {
                        IdMedicament = m.IdMedicament,
                        Dose = m.Dose,
                        Details = m.Details
                    }).ToList()
                };

                _context.Prescriptions.Add(prescription);
                await _context.SaveChangesAsync();
                transaction.Commit();

                return CreatedAtAction(nameof(CreatePrescription), new { id = prescription.IdPrescription }, prescription);
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(500, $"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
