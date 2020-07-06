using SenacNivelamento.Application.Cargos.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SenacNivelamento.Aplication.Test.Cargo
{
    public class UpdateCargoCommandTest
    {
        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateCargoCommand))]
        public void AoInstanciarSeValidoNaoDeveRetornarNotificacoes()
        {
            var command = new UpdateCargoCommand
            {
                Id = 1,
                Nome = "Cargo",
                Sigla = "C1"
            };
            Assert.True(command.IsValid());
            Assert.False(command.ValidationResult.Errors.Any());
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateCargoCommand))]
        public void AoInstanciarSemNomeDeveRetornarNotificacao()
        {
            var command = new UpdateCargoCommand
            {
                Id=1,
                Sigla = "C1"
            };

            Assert.False(command.IsValid());
            Assert.Equal(2, command.ValidationResult.Errors.Count());
        }


        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateCargoCommand))]
        public void AoInstanciarSemSiglaDeveRetornarNotificacao()
        {
            var command = new UpdateCargoCommand
            {
                Id = 1,
                Nome = "Cargo"
            };

            Assert.False(command.IsValid());
            Assert.Equal(2, command.ValidationResult.Errors.Count());
        }


        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateCargoCommand))]
        public void AoInstanciarSemIdDeveRetornarNotificacao()
        {
            var command = new UpdateCargoCommand
            {
                Nome = "Cargo",
                Sigla = "C1"
            };

            Assert.False(command.IsValid());
            Assert.Single(command.ValidationResult.Errors);
        }

        [Fact]
        [Trait("Tipo", "Unidade")]
        [Trait("Unidade", nameof(UpdateCargoCommand))]
        public void AoInstanciarSeInValidoDeveRetornarNotificacoes()
        {
            var command = new UpdateCargoCommand();

            Assert.False(command.IsValid());
            Assert.Equal(5, command.ValidationResult.Errors.Count());
        }

    }
}
