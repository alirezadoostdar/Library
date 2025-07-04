﻿using LibraryApi.Models.Persons;

namespace LibraryApi.Models.Members;

public interface IMemberRepository
{
    void Add(Member member);
    void Update(Member member);
    void Delete(int id);
    Member? GetById(int id);
    List<GetMemberDto> GetAll();
}
public class MemberRepository : IMemberRepository
{
    public readonly ApplicationDbContext _context;

    public MemberRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var member = GetById(id);
        _context.Members.Remove(member);
        _context.SaveChanges();
    }

    public List<GetMemberDto> GetAll()
    {
        return _context.Members.Select(x => new GetMemberDto(
            x.Id,
            x.Name,
            x.Family,
            x.ContactInfo.Address,
            x.ContactInfo.PhoneNumber,
            x.MembershipNumber,
            x.MembershipDate)).ToList();
    }

    public Member? GetById(int id)
    {
        return _context.Members.Find(id);
    }

    public void Update(Member member)
    {
        _context.Members.Update(member);
        _context.SaveChanges();
    }
}
