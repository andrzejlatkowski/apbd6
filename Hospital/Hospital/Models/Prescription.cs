using System.Text.Json.Serialization;

namespace Hospital.Models;

public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    
    [JsonIgnore]
    public virtual Patient IdPatientNavigation { get; set; }
    [JsonIgnore]
    public virtual Doctor IdDoctorNavigation { get; set; }
    public virtual ICollection<Prescription_Medicament> PrescriptionMedicaments { get; set; }
}