﻿using Api_backend_university.ContextDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Api_backend_university.Repository.Imp
{
    public class ImpClassRepository : IClassRepository
    {
        UniversityDb2Context _universityDb;

        public ImpClassRepository(UniversityDb2Context universityDb)
        {
            _universityDb = universityDb;
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return _universityDb.Classes.Include(a => a.Course).AsEnumerable<Class>().ToList();
        }

        public async Task<int> RegisterClass(Class classNew)
        {
            EntityEntry<Class> classModel = _universityDb.Classes.Add(classNew);
            await _universityDb.SaveChangesAsync();

            return classModel.Entity.Id;
        }
    }
}
