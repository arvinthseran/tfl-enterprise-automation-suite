﻿namespace ConfigurationBuilder;

public interface IConfigSection
{
    T GetConfigSection<T>();
}