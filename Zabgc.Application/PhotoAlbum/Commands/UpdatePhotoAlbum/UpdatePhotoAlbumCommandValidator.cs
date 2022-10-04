using FluentValidation;

namespace Zabgc.Application.PhotoAlbum.Commands.UpdatePhotoAlbum
{
    public class UpdatePhotoAlbumCommandValidator : AbstractValidator<UpdatePhotoAlbumCommand>
    {
        public UpdatePhotoAlbumCommandValidator()
        {
            RuleFor(updatePhotoAlbumCommand =>
            updatePhotoAlbumCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(updatePhotoAlbumCommand =>
            updatePhotoAlbumCommand.Department).NotEmpty();
        }
    }
}
