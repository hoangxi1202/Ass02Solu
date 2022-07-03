using BusinessObject.Models;

namespace BusinessObject.Repository
{
    public interface IMemberRepository
    {
        IEnumerable<Member> GetMembers();
        void InsertMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(int memberID);
        Member GetMemberByID(int memberID);
        bool CheckLogin(string userName, string password);
        bool IsAdmin(string userName, string password);
    }
}
