bool cache = false;
int cacheResult=0;

var num = await CachedFunc();

var i = await CachedFunc();

async Task<int> LoadCache()
{
    // simula async work:
    await Task.Delay(100);
    cacheResult = 100;
    cache = true;
    return cacheResult;
}

ValueTask<int> CachedFunc()
{
    return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
}
