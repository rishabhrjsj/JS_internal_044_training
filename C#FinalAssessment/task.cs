using System;

namespace HospitalManagementSystem
{
    // ---------------- DELEGATE ----------------
    public delegate double BillingStrategy(double amount);

    // ---------------- ABSTRACT PATIENT ----------------
    abstract class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract double CalculateBaseBill();
    }

    // ---------------- GENERAL PATIENT ----------------
    class GeneralPatient : Patient
    {
        public override double CalculateBaseBill()
        {
            return 2000;
        }
    }

    // ---------------- EMERGENCY PATIENT ----------------
    class EmergencyPatient : Patient
    {
        public override double CalculateBaseBill()
        {
            return 5000;
        }
    }

    // ---------------- HOSPITAL ----------------
    class Hospital
    {
        // EVENT
        public event Action<string> OnPatientAdmitted;

        public void AdmitPatient(Patient patient, BillingStrategy billingStrategy)
        {
            Console.WriteLine("\nPatient Admitted Successfully");

            // Step 3: Calculate base bill
            double baseBill = patient.CalculateBaseBill();

            // Step 4: Apply billing strategy
            double finalBill = billingStrategy(baseBill);

            // Step 5: Generate bill
            Console.WriteLine($"Patient Name: {patient.Name}");
            Console.WriteLine($"Base Bill: ₹{baseBill}");
            Console.WriteLine($"Final Bill: ₹{finalBill}");

            // Step 6: Trigger event
            OnPatientAdmitted?.Invoke(patient.Name);
        }
    }

    // ---------------- PROGRAM ----------------
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            // Subscribe departments to event
            hospital.OnPatientAdmitted += NotifyPharmacy;
            hospital.OnPatientAdmitted += NotifyAccounts;

            Console.Write("Enter Patient Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Select Patient Type:");
            Console.WriteLine("1. General");
            Console.WriteLine("2. Emergency");

            int choice = int.Parse(Console.ReadLine());

            Patient patient;

            if (choice == 1)
                patient = new GeneralPatient();
            else
                patient = new EmergencyPatient();

            patient.Name = name;

            // Billing Strategy using delegate
            BillingStrategy strategy;

            if (choice == 1)
                strategy = ApplyInsuranceDiscount;
            else
                strategy = ApplyEmergencyCharges;

            // Admit patient
            hospital.AdmitPatient(patient, strategy);

            Console.ReadLine();
        }

        // ---------------- BILLING STRATEGIES ----------------
        static double ApplyInsuranceDiscount(double amount)
        {
            return amount * 0.8; // 20% discount
        }

        static double ApplyEmergencyCharges(double amount)
        {
            return amount * 1.3; // 30% extra
        }

        // ---------------- EVENT HANDLERS ----------------
        static void NotifyPharmacy(string patientName)
        {
            Console.WriteLine($"Pharmacy notified for patient {patientName}");
        }

        static void NotifyAccounts(string patientName)
        {
            Console.WriteLine($"Accounts department notified for patient {patientName}");
        }
    }
}
