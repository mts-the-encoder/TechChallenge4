﻿using Domain.Repositories;
using Moq;

namespace Utils.Tests.Repositories;

public class UnitOfWorkBuilder
{
    private static UnitOfWorkBuilder _instance;
    private readonly Mock<IUnitOfWork> _repository;

    public UnitOfWorkBuilder()
    {
        _repository ??= new Mock<IUnitOfWork>();
    }

    public static UnitOfWorkBuilder Instance()
    {
        _instance = new UnitOfWorkBuilder();
        return _instance;
    }

    public IUnitOfWork Build()
    {
        return _repository.Object;
    }
}