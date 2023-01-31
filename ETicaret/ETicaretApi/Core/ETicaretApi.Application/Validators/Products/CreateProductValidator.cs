using ETicaretApi.Application.Features.Commands.Product.CreateProduct;
using ETicaretApi.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Validators.Products
{
	public class CreateProductValidator:AbstractValidator<CreateProductCommandRequest>
	{
		public CreateProductValidator()
		{
			RuleFor(p => p.Name).NotEmpty()
			.NotNull()
			.WithMessage("Ürün adı boş geçilemez")
			.MaximumLength(150)
			.MinimumLength(2).WithMessage("ürü adi 150 ile 2 karakter arasinda olmali");

			RuleFor(p => p.Stock).NotEmpty()
				.WithMessage("stok bos geçilemez")
				.Must(s => s >= 0).WithMessage("stok 0 dan kucuk olamaz");


			RuleFor(p => p.Price).NotEmpty()
				.WithMessage("fiyat bos geçilemez")
				.Must(s => s >= 0).WithMessage("fiyat 0 dan kucuk olamaz");

		}
	}
}
