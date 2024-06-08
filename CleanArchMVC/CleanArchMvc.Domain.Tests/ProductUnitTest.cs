using CleanArchMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "Create Product With Invalid Id Value")]
        public void CreateProduct_WithInvalidId_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product With Invalid Name Value Null")]
        public void CreateProduct_WithNullProductName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Empty Name Value")]
        public void CreateProduct_WithEmptyProductName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product With Too Short Name Value")]
        public void CreateProduct_WithTooShortProductName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product With Invalid Desctiption Value Null")]
        public void CreateProduct_WithNullProductDescription_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Empty Description Value")]
        public void CreateProduct_WithEmptyProductDescription_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product With Too Short Description Value")]
        public void CreateProduct_WithTooShortProductDescriotion_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product Name", "Pr", 9.99m, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 3 characters");
        }

        [Theory(DisplayName = "Create Product With Invalid Product Price Value")]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidProductPriceValue_DomainExceptionInvalidPrice(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", value, 99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product With Invalid Product Stock Value")]
        public void CreateProduct_WithInvalidProductStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -99, "Product image");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product With Invalid Image Value")]
        public void CreateProduct_WithInvalidProductImageValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99,
                "asdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçasdfghjklçe");
            action.Should()
                .Throw<CleanArchMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create Product With Valid Parameters without image and null exception")]
        public void CreateProduct_WithValidParametersWithoutImageValue_ResultObjectValidStateWithoutNullException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Valid Parameters without image")]
        public void CreateProduct_WithValidParametersWithoutImageValue_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Valid Parameters")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product image");
            action.Should()
                .NotThrow<CleanArchMVC.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
