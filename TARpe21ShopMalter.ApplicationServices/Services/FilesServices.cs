﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe21ShopMalter.Core.Domain;
using TARpe21ShopMalter.Core.Dto;
using TARpe21ShopMalter.Data;

namespace TARpe21ShopMalter.ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        private readonly TARpe21ShopMalterContext _context;
        public FilesServices
            (
                TARpe21ShopMalterContext context
            )
        {
            _context = context;
        }
        public void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo( target );
                        files.ImageData = target.ToArray();

                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
        public async Task <FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var image = await _context.FilesToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();
            _context.FilesToDatabase.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.FilesToDatabase
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefaultAsync();
                _context.FilesToDatabase.Remove(image);
                await _context.SaveChangesAsync();
            }
            return null;
        }
    }
}