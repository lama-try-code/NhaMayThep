﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu.DeleteChucVu
{
    public class DeleteChucVuCommandHandler : IRequestHandler<DeleteChucVuCommand, string>
    {
        private readonly IChucVuRepository _chucVuRepository;
        public DeleteChucVuCommandHandler(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }
        public async Task<string> Handle(DeleteChucVuCommand command, CancellationToken cancellationToken)
        {
            var result = await _chucVuRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Chuc vu with {command.Id} not found");
            result.NgayXoa = DateTime.Now;
            if (await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Remove Successfully";
            else
                msg = "Remove Failed";
            return msg;
        }
    }
}
