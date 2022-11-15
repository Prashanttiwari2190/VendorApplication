using Xunit;

/* NOTE:
 * This attribute is required because normally the tests are run in parallel. Normally this is a good thing,
 * but for these integration tests we use the same objects over and over. So if we run the tests in parallel,
 * we get exceptions related to duplicate keys. The solution is to run these tests serially.
 */