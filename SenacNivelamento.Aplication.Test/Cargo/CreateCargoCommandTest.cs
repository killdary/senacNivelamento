using Microsoft.EntityFrameworkCore.Internal;
using SenacNivelamento.Application.Cargos.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SenacNivelamento.Aplication.Test.Cargo
{
    public class CreateCargoCommandTest
    {
        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateCargoCommand))]
        public void AoInstanciarSeValidoNaoDeveRetornarNotificacoes()
        {
            var command = new CreateCargoCommand
            {
                Nome = "Cargo",
                Sigla = "C1"
            };
            Assert.True(command.IsValid());
            Assert.False(command.ValidationResult.Errors.Any());
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateCargoCommand))]
        public void AoInstanciarSemNomeDeveRetornarNotificacao()
        {
            var command = new CreateCargoCommand { 
                Sigla="C1"
            };

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }


        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateCargoCommand))]
        public void AoInstanciarSemSiglaDeveRetornarNotificacao()
        {
            var command = new CreateCargoCommand
            {
                Nome = "Cargo"
            };

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }


        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(CreateCargoCommand))]
        public void AoInstanciarSeInValidoDeveRetornarNotificacoes()
        {
            var command = new CreateCargoCommand();

            Assert.False(command.IsValid());
            Assert.True(command.ValidationResult.Errors.Any());
        }

    }
}
