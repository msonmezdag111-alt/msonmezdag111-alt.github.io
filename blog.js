const blogs = document.querySelectorAll(".blogitem");

blogs.forEach((blog) => {
  blog.addEventListener("toggle", () => {
    if (blog.open) {
      blogs.forEach((andereBlog) => {
        if (andereBlog !== blog) {
          andereBlog.open = false;
        }
      });
    }
  });
});
