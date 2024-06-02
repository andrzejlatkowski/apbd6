using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Hospital.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public Patient IdPatient { get; set; }
    public Doctor IdDoctor { get; set; }
    
    public virtual Patient IdPatientNavigation { get; set; }
    public virtual Doctor IdDoctorNavigation { get; set; }
    
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}