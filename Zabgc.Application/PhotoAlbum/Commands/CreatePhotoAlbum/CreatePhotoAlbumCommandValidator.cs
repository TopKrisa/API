using FluentValidation;

namespace Zabgc.Application.PhotoAlbum.Commands.CreatePhotoAlbum
{
    public class CreatePhotoAlbumCommandValidator : AbstractValidator<CreatePhotoAlbumCommand>
    {
        public CreatePhotoAlbumCommandValidator()
        {
            RuleFor(createPhotoAlbumCommand =>
            createPhotoAlbumCommand.Name).NotEmpty().MaximumLength(100);
            RuleFor(createPhotoAlbumCommand =>
            createPhotoAlbumCommand.Department).NotEmpty();
        }
    }
}
