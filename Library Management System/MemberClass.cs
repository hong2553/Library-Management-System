using System.ComponentModel;

namespace Library_Management_System
{
    public class MemberClass
    {
        public int MemberID { get; set; }

        [DisplayName("Name")]
        public string MemberName { get; set; } = "";

        public char Gender { get; set; }  // M_Gender: 'M' or 'F'

        public string Phone { get; set; } = "";

        [DisplayName("Registered")]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        public MemberClass() { }

        public MemberClass(int memberID, string memberName, char gender, string phone,
                           DateTime? registerDate = null)
        {
            MemberID = memberID;
            MemberName = memberName;
            Gender = gender;
            Phone = phone;
            RegisterDate = registerDate ?? DateTime.Now;
        }

        public override string ToString() => MemberName;
    }
}