﻿using FluentAssertions;
using MyHome.Domain.Aggregate;
using MyHome.Domain.Services;
using Xunit;

namespace MyHome.Domain.Test.Services
{
    public class OrderStrategyTest
    {

        [Fact]
        public void When_add_families_with_incomes_should_be_get_next_by_order_correctly()
        {
            Family family1 = new(900);
            Family family2 = new(1200);

            HomeQueue queue = new();

            queue.AddFamily(family1);
            queue.AddFamily(family2);

            var ableFamily = queue.GetAbleFamily(new OrderStrategy());

            ableFamily.Should().Be(family1);
        }

        [Fact]
        public void When_add_families_with_incomes_and_dependents_should_be_get_next_by_order_correctly()
        {
            Family family1 = new(900);
            Family family2 = new(1200);

            family2.AddDependent(new Dependent { BirthDate = DateTime.Today.AddYears(-17) });
            family2.AddDependent(new Dependent { BirthDate = DateTime.Today.AddYears(-11) });
            family2.AddDependent(new Dependent { BirthDate = DateTime.Today.AddYears(-9) });

            HomeQueue queue = new();

            queue.AddFamily(family1);
            queue.AddFamily(family2);

            var ableFamily = queue.GetAbleFamily(new OrderStrategy());

            ableFamily.Should().Be(family2);
        }

        [Fact]
        public void When_add_families_with_incomes_and_dependents_nonage_should_be_get_next_by_order_correctly()
        {
            Family family1 = new(900);
            Family family2 = new(1200);

            family2.AddDependent(new Dependent { BirthDate = DateTime.Today.AddYears(-19) });
            family2.AddDependent(new Dependent { BirthDate = DateTime.Today.AddYears(-20) });
           
            HomeQueue queue = new();

            queue.AddFamily(family1);
            queue.AddFamily(family2);

            var ableFamily = queue.GetAbleFamily(new OrderStrategy());

            ableFamily.Should().Be(family1);
        }

        [Fact]
        public void When_add_families_invalid_or_null_should_be_throws_exception()
        {
            Family family1 = null;
           
            HomeQueue queue = new();

            Action act = () => queue.AddFamily(family1);

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("family");
        }

        [Fact]
        public void When_add_dependent_invalid_or_null_should_be_throws_exception()
        {
            Family family1 = new(900);

            Action act = () => family1.AddDependent(null);

            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("dependent");
        }
    }
}
