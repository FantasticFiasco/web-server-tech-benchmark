package main

func caesar(r rune, shift int) rune {

	// I got some really hefty limitations here:
	//   - I only support the English alphabet
	//   - I only support lowercase characters
	//   - ...
	// Please don't sue me!

	s := int(r) + shift

	if s > 'z' {
		return rune(s - 26)
	} else if s < 'a' {
		return rune(s + 26)
	}

	return rune(s)
}
