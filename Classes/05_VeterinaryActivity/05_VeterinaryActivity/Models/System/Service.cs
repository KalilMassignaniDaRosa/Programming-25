namespace _05_VeterinaryActivity.Models.System
{
    public class Service
    {
        private readonly List<string> _notes = new();

        public DateTime Date { get; set; }
        public string? Procedure { get; set; }
        public Doctor? ResponsibleDoctor { get; set; }
        public Animal? Patient { get; set; }
        public Client? Owner { get; set; }

        public void AddNote(string note)
        {
            _notes.Add(note);
        }

        public IReadOnlyList<string> GetNotes()
        {
            return _notes.AsReadOnly();
        }
    }
}
